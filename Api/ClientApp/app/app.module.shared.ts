import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { FetchTeacherComponent } from './components/fetchteachercomponent/fetchteacher.component';
import { createteacher } from './components/AddTeacherComponent/addteacher.component';
import { TeacherService } from '../services/teacherservice.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        FetchTeacherComponent,
        createteacher
    ],
    imports: [
        CommonModule,  
        HttpModule,  
        FormsModule,  
        ReactiveFormsModule,  
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'fetch-teacher', component: FetchTeacherComponent },
            { path: 'register-teacher', component: createteacher},
            { path: 'teacher/edit/:teacherId', component: createteacher},
            { path: '**', redirectTo: 'home' }
        ]),
    ],

    providers: [TeacherService],
    bootstrap: [AppComponent]
})
export class AppModuleShared {
}
