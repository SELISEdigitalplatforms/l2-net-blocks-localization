using DomainService.Repositories;
using DomainService.Services.HelperService;
using DomainService.Shared;
using DomainService.Shared.Entities;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace XUnitTest
{
    public class WebHookServiceTests
    {
        private readonly Mock<IBlocksWebhookRepository> _blocksWebhookRepository = new();
        private readonly Mock<IHttpHelperServices> _httpHelperServices = new();
        private readonly Mock<ILogger<WebHookService>> _logger = new();
        private readonly WebHookService _service;

        public WebHookServiceTests()
        {
            _service = new WebHookService(_blocksWebhookRepository.Object, _httpHelperServices.Object, _logger.Object);
        }

        [Fact]
        public async Task CallWebhook_WhenNoWebhookConfigured_ReturnsTrueAndSkipsHttp()
        {
            _blocksWebhookRepository.Setup(r => r.GetAsync()).ReturnsAsync((BlocksWebhook?)null);

            var result = await _service.CallWebhook(new { ok = true });

            result.Should().BeTrue();
            _httpHelperServices.Verify(h => h.MakeHttpRequestForWebhook(It.IsAny<object>(), It.IsAny<BlocksWebhook>()), Times.Never);
        }

        [Fact]
        public async Task CallWebhook_WhenWebhookDisabled_ReturnsTrueAndSkipsHttp()
        {
            var webhook = new BlocksWebhook
            {
                Url = "https://callback.test/webhook",
                ContentType = "application/json",
                BlocksWebhookSecret = new BlocksWebhookSecret { HeaderKey = "X-Signature", Secret = "secret" },
                IsDisabled = true,
                ProjectKey = "proj"
            };
            _blocksWebhookRepository.Setup(r => r.GetAsync()).ReturnsAsync(webhook);

            var result = await _service.CallWebhook(new { ok = true });

            result.Should().BeTrue();
            _httpHelperServices.Verify(h => h.MakeHttpRequestForWebhook(It.IsAny<object>(), It.IsAny<BlocksWebhook>()), Times.Never);
        }

        [Fact]
        public async Task CallWebhook_WhenWebhookEnabled_ForwardsToHttpHelper()
        {
            var webhook = new BlocksWebhook
            {
                Url = "https://callback.test/webhook",
                ContentType = "application/json",
                BlocksWebhookSecret = new BlocksWebhookSecret { HeaderKey = "X-Signature", Secret = "secret" },
                IsDisabled = false,
                ProjectKey = "proj"
            };
            _blocksWebhookRepository.Setup(r => r.GetAsync()).ReturnsAsync(webhook);
            _httpHelperServices
                .Setup(h => h.MakeHttpRequestForWebhook(It.IsAny<object>(), webhook))
                .ReturnsAsync(true);

            var payload = new { ok = true };
            var result = await _service.CallWebhook(payload);

            result.Should().BeTrue();
            _httpHelperServices.Verify(h => h.MakeHttpRequestForWebhook(payload, webhook), Times.Once);
        }

        [Fact]
        public async Task SaveWebhookAsync_WhenSaveSucceeds_ReturnsSuccess()
        {
            var webhook = new BlocksWebhook
            {
                Url = "https://callback.test/webhook",
                ContentType = "application/json",
                BlocksWebhookSecret = new BlocksWebhookSecret { HeaderKey = "X-Signature", Secret = "secret" },
                ProjectKey = "proj"
            };

            _blocksWebhookRepository.Setup(r => r.SaveAsync(webhook)).Returns(Task.CompletedTask);

            ApiResponse response = await _service.SaveWebhookAsync(webhook);

            response.Success.Should().BeTrue();
            response.ErrorMessage.Should().BeNull();
            _blocksWebhookRepository.Verify(r => r.SaveAsync(webhook), Times.Once);
        }

        [Fact]
        public async Task SaveWebhookAsync_WhenRepositoryThrows_ReturnsErrorResponse()
        {
            var webhook = new BlocksWebhook
            {
                Url = "https://callback.test/webhook",
                ContentType = "application/json",
                BlocksWebhookSecret = new BlocksWebhookSecret { HeaderKey = "X-Signature", Secret = "secret" },
                ProjectKey = "proj"
            };
            var exception = new Exception("database unavailable");

            _blocksWebhookRepository
                .Setup(r => r.SaveAsync(webhook))
                .ThrowsAsync(exception);

            ApiResponse response = await _service.SaveWebhookAsync(webhook);

            response.Success.Should().BeFalse();
            response.ErrorMessage.Should().Be(exception.Message);
            _blocksWebhookRepository.Verify(r => r.SaveAsync(webhook), Times.Once);
            _httpHelperServices.VerifyNoOtherCalls();
        }
    }
}
