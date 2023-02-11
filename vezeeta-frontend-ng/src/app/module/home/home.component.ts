import {Component, ElementRef, OnInit, TemplateRef} from '@angular/core';
import {NgbModal} from "@ng-bootstrap/ng-bootstrap";
import {TranslationService} from "../../shared/services/translation.service";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  constructor(private modalService: NgbModal, private translationService: TranslationService) {}

  ngOnInit(): void {
  }

  open(NgbdModalContent: any) {
    const modalRef = this.modalService.open(NgbdModalContent);
  }

}
