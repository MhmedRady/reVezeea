import { Component, OnInit } from '@angular/core';
import {TranslationService} from "../../shared/services/translation.service";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(public translationService: TranslationService) { }

  ngOnInit(): void {
  }
}
