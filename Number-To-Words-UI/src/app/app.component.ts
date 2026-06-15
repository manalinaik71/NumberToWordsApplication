import { Component } from '@angular/core';
import { NumberToWordConversionService } from './services/number-to-word-conversion.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Number-To-Words-UI';

  request = {
    language: '',
    amount: ''
  }
  result = '';
  errorMessage = '';

  constructor(private numberConversionService: NumberToWordConversionService) {

  }


  onSubmit(): void {
    this.result = '';
    this.errorMessage = '';

    const amountValue = this.request.amount.trim();
    const amountParts = amountValue.split(',');
    const number = Number(amountParts[0]);

    const cents = amountParts.length > 1 ?
      (amountParts[1].length == 1 ? Number(amountParts[1] + '0') : Number(amountParts[1])) : 0;

    const apiRequest = {
      language: this.request.language,
      number: number,
      cents: cents
    };

    this.numberConversionService.ConvertNumberToWords(apiRequest).subscribe({
      next: (response) => {
        this.result = response.words;
      },
      error: (error) => {
        this.errorMessage = error;
        this.result = '';
      }
    })

  }
}
