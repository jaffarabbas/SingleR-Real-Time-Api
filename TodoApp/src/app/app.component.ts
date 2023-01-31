import { Component, OnInit } from '@angular/core';
import { TodoServiceService } from './Services/todo-service.service';
import { Todo } from './Models/todo';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  public todos: Todo[] = [];
  public newTodoName = '';
  public newTodoDescription = '';

  constructor(private todoService: TodoServiceService) { }

  ngOnInit() {
    console.log('ngOnInit');
    this.todoService.onTodoAdded(todo => {
      this.todos.push(todo);
    });
  }

  public addTodo() {
    this.todoService.addTodo({
      name: this.newTodoName,
      description: this.newTodoDescription
    });
    // this.todoService.onTodoAdded(todo => {
    //   console.log('onTodoAdded');
    //   console.log(todo);
    //   this.todos.push(todo);
    // });
    this.newTodoName = '';
    this.newTodoDescription = '';
  }
}
