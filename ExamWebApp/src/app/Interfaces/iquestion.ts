import { IAnswer } from "./ianswer"

export interface IQuestion {
  id?:number,
  text: string
  degree: number
  examId: number
  choices: IAnswer[]
}
