import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ExamService } from '../../Services/exam-service';
import{IExam}from '././../../Interfaces/iexam'
import { ActivatedRoute, Router, RouterLink } from '@angular/router';



@Component({
  selector: 'app-exam',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './exam.html',
  styleUrls: ['./exam.css'],


})
export class Exam implements OnInit{
  Exams: IExam[] = []
  ExamDeletedId!: number;

  ExamId!: any;

  id!: number;

  constructor(private exam: ExamService ,private CDR:ChangeDetectorRef ,private router:Router , private route:ActivatedRoute) { }



  ngOnInit(): void {
  //  this.ExamId= +this.route.snapshot.paramMap.get('id')!;
    this.AllExams();
    // =this.route.snapshot.paramMap.get('id');
  }

  AllExams() {
    this.exam.GetAllExams().subscribe({
      next: (response) => {
        this.Exams = response as IExam[];
        console.log(this.Exams);
      }
    });


  }


   DeleteExam(id:number) {
      this.exam.DeleteExam(id).subscribe({
        next: (response: any) => {

          this.AllExams();
          this.CDR.detectChanges();
         this.Exams = this.Exams.filter(e => e.id !== id);


      }

      })

  }



  openExam( examId:number) {
    this.router.navigate([`/ShowExam/${examId}`]);
  }











  AddQuestion(examId: any) {
  // this.ExamId=examId;
    this.router.navigate([`/AddQuestion/${examId}`]);
  }




}
