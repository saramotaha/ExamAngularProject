import { IExam } from "./iexam"

export interface IStudentScore {

  id: number
  usersId: number
  examId: number
  exam: IExam
  score: number
}
