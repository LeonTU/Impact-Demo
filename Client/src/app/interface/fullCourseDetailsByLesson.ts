export interface IFullCourseDetailsByLesson {
  id: string,
  name: string,
  videoUrl: string;
  course: {
    name: string,
    sections: {
      id: string,
      name: string,
      order: number,
      lessons: {
        id: string,
        name: string,
        order: number,
        isCompleted: boolean;
      }[];
    }[];
  };
}
