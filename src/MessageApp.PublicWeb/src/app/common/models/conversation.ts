export interface Conversation{
  id:number,
  groupName?:string
  messages?:Message []
}
export interface Message{
  id:number,
  content:string
  user:UserConversation
}
export interface UserConversation{
  userId:number,
  email:string
}
