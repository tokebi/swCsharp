using System.Collections.Generic;
using System.Threading.Tasks;
using SlackAPI;

namespace SlackAPIUsing.Services
{
    /// <summary>
    /// Slackメッセージの取得に必要な機能を提供するサービス
    /// </summary>
    public class SlackMessageGetService
    {
        #region 公開サービス

        /// <summary>
        /// チャンネル一覧取得
        /// </summary>
        /// <param name="accessToken">アクセストークン</param>
        /// <returns>チャンネル一覧</returns>
        public static async Task<IEnumerable<Channel>> GetChannels(string accessToken)
        {
            var client = new SlackTaskClient(accessToken);
            var channleList = await client.GetChannelListAsync();
            return channleList.channels;
        }

        /// <summary>
        /// メッセージ一覧取得
        /// </summary>
        /// <param name="channel">チャンネル</param>
        /// <param name="accessToken">アクセストークン</param>
        /// <param name="count">取得するメッセージ数</param>
        /// <returns>メッセージ一覧</returns>
        public static async Task<IEnumerable<Message>> GetMessages(Channel channel, string accessToken, int count)
        {
            var client = new SlackTaskClient(accessToken);
            var messageHistory = await client.GetChannelHistoryAsync(channel, count: count);
            return messageHistory.messages;
        }

        #endregion
    }
}
