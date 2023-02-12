import {Inject, Injectable} from '@angular/core';
import {TranslationSet} from "./translation-set";
import arLang from 'src/app/lang/ar-EG';
import enLang from 'src/app/lang/en-EG';
import {DOCUMENT} from "@angular/common";

@Injectable({
  providedIn: 'root'
})
export class TranslationService {

  public languages = ["ar-EG", "en-US"];
  public language = "ar-EG";
  public switchLanguage = "en-US";
  public direction = "rtl";
  @Inject(DOCUMENT) doc: Document;
  private dictionary: { [key: string]: TranslationSet } = {
    "ar-EG": {
      language: "ar-EG",
      direction: "rtl",
      values: arLang,
    },
    "en-US": {
      language: "en-US",
      direction: "ltr",
      values: enLang,
    },
  }
  constructor(@Inject(DOCUMENT) doc: Document) {
    this.doc = doc;
    this.getStorageLanguage();
  }

  translate(key: string): any {
    if (this.dictionary[this.language] != null) {
      return this.dictionary[this.language].values[key]
    }
  }

  changeLanguage() {
    this.switchLanguage = this.language;
    this.language = this.language == "ar-EG"? "en-US" : "ar-EG";
    this.setLanguage();
  }

  private getStorageLanguage(){
    let currentLang = localStorage.getItem("currentLang")|| "ar-EG";
    this.switchLanguage = currentLang == "ar-EG"? "en-US" : "ar-EG";
    this.language = currentLang;
    this.setLanguage();
  }

  private setLanguage(){
    localStorage.setItem('currentLang', this.language);
    this.direction = this.dictionary[this.language].direction;
    this.doc.documentElement.dir = this.direction;
    this.doc.body.style.direction = this.direction;
    this.doc.body.dir = this.direction;
  }
}

