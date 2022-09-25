import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FullCourseDetailsByLessonComponent } from './full-course-details-by-lesson.component';

describe('FullCourseDetailsByLessonComponent', () => {
  let component: FullCourseDetailsByLessonComponent;
  let fixture: ComponentFixture<FullCourseDetailsByLessonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FullCourseDetailsByLessonComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FullCourseDetailsByLessonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
