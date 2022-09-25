import { Observable } from 'rxjs';
import { ISimpleLesson } from './../interface/lesson';
import { CourseService } from './../services/course.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-lesson-list',
  templateUrl: './lesson-list.component.html',
  styleUrls: ['./lesson-list.component.css']
})
export class LessonListComponent implements OnInit {
  lessons$!: Observable<ISimpleLesson[]>;

  constructor(private courseService: CourseService) { }

  ngOnInit(): void {
    this.lessons$ = this.courseService.getLessonList();
  }
}
