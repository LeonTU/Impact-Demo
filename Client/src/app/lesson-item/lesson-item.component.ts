import { CourseService } from './../services/course.service';
import { ISimpleLesson } from './../interface/lesson';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-lesson-item',
  templateUrl: './lesson-item.component.html',
  styleUrls: ['./lesson-item.component.css']
})
export class LessonItemComponent implements OnInit {
  @Input() lesson!: ISimpleLesson;
  percentageWatched: number = 0;
  feedbackMessage: string = '';

  constructor(private courseService: CourseService) { }

  ngOnInit(): void { }

  updatePercentageWatched() {
    if (this.percentageWatched <= 0 || this.percentageWatched > 100) {
      this.feedbackMessage = 'Please inter a number greater than 0 and not more than 100';
      return;
    } else {
      this.feedbackMessage = '';
    }

    this.courseService.postWatchLog(this.lesson.id, this.percentageWatched).subscribe(
      {
        next: () => this.feedbackMessage = 'New watchlog posted successfully',
        error: error => {
          this.feedbackMessage = 'New watchlog posted unsuccessfully';
          console.log(error);
        }
      }
    );

    this.percentageWatched = 0;
  }
}
