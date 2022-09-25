import { AuthService } from './../services/auth.service';
import { IFullCourseDetailsByLesson } from './../interface/fullCourseDetailsByLesson';
import { Observable } from 'rxjs';
import { CourseService } from './../services/course.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-full-course-details-by-lesson',
  templateUrl: './full-course-details-by-lesson.component.html',
  styleUrls: ['./full-course-details-by-lesson.component.css']
})
export class FullCourseDetailsByLessonComponent implements OnInit {
  course$!: Observable<IFullCourseDetailsByLesson>;
  hintMessage = '';

  constructor(private courseService: CourseService,
    private routes: ActivatedRoute,
    private authService: AuthService) { }

  ngOnInit(): void {
    const id = this.routes.snapshot.paramMap.get('id');
    if (id) {
      this.authService.auth$.subscribe(auth => {
        this.course$ = this.courseService.getFullCourseDetailsByLessonId(id);
        this.hintMessage = auth == null
          ? 'Guest sees the summary of this field, IsCompleted will be true if anyone completed the lesson'
          : 'Loggin user sees his/her own result, IsCompleted will only be true if the user completed the lesson';
      });
    }
  }
}
