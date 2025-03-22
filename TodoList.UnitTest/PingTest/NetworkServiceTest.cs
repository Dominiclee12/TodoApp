using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using TodoList.NetworkUtility.Ping;

namespace TodoList.UnitTest.PingTest
{
    public class NetworkServiceTest
    {
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // arrange - variables, classes, mocks
            NetworkService networkService = new NetworkService();

            // act
            var result = networkService.SendPing();

            // assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Ping Sent");
        }

        [Theory]
        [InlineData(1, 1, 2)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            // arrange
            NetworkService networkService = new NetworkService();

            // act
            var result = networkService.PingTimeout(a, b);

            // assert
            result.Should().Be(expected);
        }
    }
}
