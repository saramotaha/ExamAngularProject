import { ChangeDetectorRef, Component, NgZone, OnInit } from '@angular/core';
import { ExamService } from '../../Services/exam-service';
import{IExam}from '././../../Interfaces/iexam'
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import { RoleService } from '../../Services/role-service';
import { CommonModule } from '@angular/common';



@Component({
  selector: 'app-exam',
  standalone: true,
  imports: [RouterLink,CommonModule],
  templateUrl: './exam.html',
  styleUrls: ['./exam.css'],


})
export class Exam implements OnInit{
  Exams: IExam[] = []
  ExamDeletedId!: number;


  ExamId!: any;

  id!: number;

  roleName: string='';

  constructor(private exam: ExamService ,private CDR:ChangeDetectorRef ,private router:Router , private route:ActivatedRoute , private role:RoleService , private zone:NgZone) { }



  ngOnInit(): void {
  //  this.ExamId= +this.route.snapshot.paramMap.get('id')!;
    this.AllExams();
    // =this.route.snapshot.paramMap.get('id');

    this.role.getRole().subscribe({
      next: (response) => {

        this.roleName = response.role;

        this.roleName = response.role.toLowerCase();



        console.log(this.roleName);


      }
    })
  }

  AllExams() {
    this.exam.GetAllExams().subscribe({
      next: (response) => {
        this.Exams = response as IExam[];
        this.CDR.detectChanges();
        console.log(this.Exams);

      }
    });


  }




   DeleteExam(id:number) {
      this.exam.DeleteExam(id).subscribe({
        next: (response: any) => {



          // this.Exams = this.Exams.filter(e => e.id !== id);
          this.AllExams();
          this.router.navigate(['/Dashboard/Exam']);
          this.CDR.detectChanges();




      }

      })

  }



  openExam( examId:number) {
    this.router.navigate([`/Dashboard/ShowExam/${examId}`]);
  }











  AddQuestion(examId: any) {
  this.ExamId=examId;
    // window.location.reload();

    this.router.navigate([`/Dashboard/AddQuestion/${this.ExamId}`]);

  }




}
