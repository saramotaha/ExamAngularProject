import { IAnswer } from "./ianswer"

export interface IQuestion {
  text: string
  degree: number
  examId: number
  choices: IAnswer[]
}
