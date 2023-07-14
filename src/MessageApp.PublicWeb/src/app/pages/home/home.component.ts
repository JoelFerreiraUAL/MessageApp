import { Component } from '@angular/core';
import { Conversation, UserConversation } from 'src/app/common/models/conversation';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {

  public conversations:Conversation []=[];
  public selectedConversation:Conversation
  constructor(){

  }
  ngOnInit(){
    this.getData();

  }
  getData(){
    this.conversations=[
      {
        id:1,
        groupName:"AMIGOS",
        messages:[
          {
            id:1,
            content:"Olá como estás tudo bem?",
            user:{ userId:2,email:"joel141996@gmail.com" } as UserConversation
          },
          {
            id:2,
            content:"Sim e tu como andas?",
            user:{ userId:1,email:"j141996@hotmail.com" } as UserConversation
          }
        ]

      }
    ]
  }
}
