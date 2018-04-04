import {Component, OnInit, NgModule} from '@angular/core';
import {Http, Headers} from '@angular/http';
import {NgForm, FormBuilder, FormGroup, Validators, FormControl} from '@angular/forms';
import {Router, ActivatedRoute} from '@angular/router';
import {FetchTeacherComponent} from '../fetchteachercomponent/fetchteacher.component';
import { TeacherService } from '../../../services/teacherservice.service';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component ({
    selector: 'createteacher',
    templateUrl: './addteacher.component.html',
})

@NgModule({
    imports: [
        FormsModule,   
        ReactiveFormsModule 
    ]
})

export class createteacher implements OnInit{
    teacherForm: FormGroup ;
    title: string = "Dodaj";
    teacherid: string = "" ;
    errorMessage: any;

    constructor(private _fb: FormBuilder, private _avRoute: ActivatedRoute,
    private _teacherService: TeacherService, private _router: Router, ){
        if(this._avRoute.snapshot.params["teacherId"]){
            this.teacherid = this._avRoute.snapshot.params["teacherId"];
        }
            this.teacherForm = this._fb.group({
                teacherid: [null],
                firstname: ['', [Validators.required]],
                lastname: ['', [Validators.required]],
                languages: ['', [Validators.required]],
                city: ['', [Validators.required]],
                address: ['', [Validators.required]],
                zipcode: ['', [Validators.required]]
            });    
    }

    ngOnInit() {
        if(this.teacherid > ""){
            this.title = "Edycja";
            this._teacherService.getTeacherById(this.teacherid)
            .subscribe(resp => this.teacherForm.patchValue({
                teacherid: resp.teacherId,
                firstname: resp.firstName,
                lastname: resp.lastName,
                languages: resp.languages,
                city: resp.city,
                address: resp.address,
                zipcode: resp.zipCode
            })
        , error => this.errorMessage = error);
        }
    }

    save(){
        if(!this.teacherForm.valid){
            return;
        }

        if(this.title == "Dodaj"){
            this._teacherService.saveTeacher(this.teacherForm.value)
            .subscribe((data) => {
                this._router.navigate(['/fetch-teacher']);
            }, error => this.errorMessage(error))
        }
        else if(this.title == "Edycja"){
            this._teacherService.editTeacher(this.teacherForm.value)
            .subscribe((data) => {
                this._router.navigate(['fetch-teacher']);
            }, error => this.errorMessage(error))
        }
    }

    cancel(){
        this._router.navigate(['/fetch-teacher']);
    }

    get firstname() {return this.teacherForm.get("firstname");}
    get lastname() {return this.teacherForm.get("lastname");}
    get languages() {return this.teacherForm.get("languages");}
    get city() {return this.teacherForm.get("city");}
    get address() {return this.teacherForm.get("address");}
    get zipcode() {return this.teacherForm.get("zipcode");}
}