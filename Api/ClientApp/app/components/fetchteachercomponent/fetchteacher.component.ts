import {Component, Inject} from '@angular/core';
import {Http, Headers} from '@angular/http';
import {Router, ActivatedRoute} from '@angular/router';
import {TeacherService} from '../../../services/teacherservice.service';

@Component({
    selector: 'fetchteacher',
    templateUrl: './fetchteacher.component.html'
})

export class FetchTeacherComponent{
    public teachList: TeacherData[];

    constructor(public http: Http, private _router: Router, private _teacherService: TeacherService)
    {
        this.getTeachers();
    }

    getTeachers(){
        this._teacherService.getTeachers().subscribe(
            data => this.teachList = data
        )
    }

    deleteTeacher(teacherid){
        var ans = confirm("Czy na pewno chcesz usunąc nauczyciela?");
        if(ans)
        {
            this._teacherService.deleteTeacher(teacherid).subscribe((data) => {
                this.getTeachers();
            }, error => console.error(error));
        }
    }
}

interface TeacherData {
    teacherid: string;
    firstname: string;
    lastname: string;
    languages: string;
    city: string;
    address: string;
    zipcode: string;
}