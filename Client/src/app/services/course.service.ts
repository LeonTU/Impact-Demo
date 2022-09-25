import { IFullCourseDetailsByLesson } from './../interface/fullCourseDetailsByLesson';
import { ISimpleLesson } from './../interface/lesson';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CourseService {
  baseUrl = `${environment.apiUrl}/api/courses`;

  constructor(private http: HttpClient) { }

  getLessonList() {
    return this.http.get<ISimpleLesson[]>(`${this.baseUrl}/lesson`);
  }

  getFullCourseDetailsByLessonId(lessonId: string) {
    return this.http.get<IFullCourseDetailsByLesson>(`${this.baseUrl}/lesson/${lessonId}`);
  }

  postWatchLog(lessonId: string, percentageWatched: number) {
    return this.http
      .post(`${this.baseUrl}/watchlog/${lessonId}`, null, { params: { pw: percentageWatched } });

  }
}
