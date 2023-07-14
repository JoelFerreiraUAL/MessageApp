import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Conversation } from '../../models/conversation';

@Injectable({
  providedIn: 'root'
})
export class ConversationService {

  constructor(private http: HttpClient,) { }

  getConversations() {
    return this.http.get<Conversation[]>(`https://localhost:7255/api/conversation`);

  }
}
