import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ControlMessagesComponent } from './components/control-messages/control-messages.component';
import { TranslatePipe } from './pipes/translate.pipe';

@NgModule({
    declarations: [
        ControlMessagesComponent,
        TranslatePipe
    ],
    exports: [
        TranslatePipe
    ],
    imports: [
        CommonModule
    ]
})
export class SharedModule { }
