import { Injectable } from '@angular/core';
import { Todo } from '../Models/todo';
import { HttpClient } from '@angular/common/http';
import { HubConnection } from '@microsoft/signalr';
import { HubConnectionBuilder } from '@microsoft/signalr/dist/esm/HubConnectionBuilder';
import * as signalR from '@microsoft/signalr';
@Injectable({
  providedIn: 'root'
})
export class TodoServiceService {
  private _hubConnection: HubConnection;

  constructor(private http: HttpClient) {
    // this._hubConnection = new signalR.HubConnectionBuilder
    //   .withUrl('https://localhost:7089/todos', {
    //     skipNegotiation: true,
    //     transport: signalR.HttpTransportType.WebSockets
    //   })
    //   .build();

    this._hubConnection = new signalR.HubConnectionBuilder()
      .configureLogging(signalR.LogLevel.Debug)
      .withUrl("https://localhost:7089/todos", {
        skipNegotiation: true,
        transport: signalR.HttpTransportType.WebSockets
      })
      .build();

    this._hubConnection.start().then(() => { console.log('Connected') }).catch(err => console.error('Heavy Error : ' + err));
  }

  public addTodo(todo: Todo) {
    console.log('addTodo');
    console.log(todo);
    console.log()
    return this.http.post('https://localhost:7089/api/todo', todo);
  }

  public onTodoAdded(callback: (todo: Todo) => void) {
    this._hubConnection.on('AddTodoHere', (data) => {
      console.log('onTodoAdded');
      callback(data);
    });
  }
}
