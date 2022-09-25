import { FullCourseDetailsByLessonComponent } from './full-course-details-by-lesson/full-course-details-by-lesson.component';
import { LessonListComponent } from './lesson-list/lesson-list.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

export const routes: Routes = [
  { path: '', component: LessonListComponent },
  { path: 'lesson/:id', component: FullCourseDetailsByLessonComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];

@NgModule({

  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
