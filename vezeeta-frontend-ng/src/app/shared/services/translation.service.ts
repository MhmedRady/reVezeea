import { Injectable } from '@angular/core';
import {TranslationSet} from "./translation-set";
import arLang from 'src/app/lang/ar-EG';
import enLang from 'src/app/lang/en-EG';

@Injectable({
  providedIn: 'root'
})
export class TranslationService {

  public languages = ["ar-EG", "en-US"];
  public language = "en-US";

  private dictionary: { [key: string]: TranslationSet } = {
    "ar-EG": {
      languange: "ar-EG",
      values: arLang,
    },
    "en-US": {
      languange: "en-US",
      values: enLang,
    },
  }
  constructor() { }

  translate(key: string): any {
    if (this.dictionary[this.language] != null) {
      return this.dictionary[this.language].values[key]
    }
  }

  changeLanguage() {
    this.language = this.language == "ar-EG"? "en-US" : "ar-EG";
    document.body.style.direction = this.language == "ar-EG" ? "rtl" : "ltr";
  }
}

