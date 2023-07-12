namespace MessageApp.Contracts.Requests.Conversation
{
    public record CreateConversationRequest
    (
      string GroupName,
      List<CreateMessageRequest>? Messages

    );
    public record CreateMessageRequest
    (
     string Content,
     int userId
    );

}
