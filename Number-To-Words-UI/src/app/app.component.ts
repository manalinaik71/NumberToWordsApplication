import { Component } from '@angular/core';
import { NumberToWordConversionService } from './services/number-to-word-conversion.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Number-To-Words-UI';
  request: { language: string; amount: string } = {
    language: '',
    amount: ''
  };
  languages = [
  { label: 'English', value: 'en' },
  { label: 'German', value: 'de' }
  ];
  result = '';
  errorMessage = '';

  constructor(private numberConversionService: NumberToWordConversionService) {

  }


  onSubmit(): void {
    this.result = '';
    this.errorMessage = '';

    const amountValue = this.request.amount.trim();
    const amountParts = amountValue.split(',');
    const dollars = Number(amountParts[0]);

    const cents = amountParts.length > 1 ?
      (amountParts[1].length === 1 ? Number(amountParts[1] + '0') : Number(amountParts[1])) : 0;

    const apiRequest = {
      language: this.request.language,
      number: dollars,
      cents: cents
    };

    this.numberConversionService.convertNumberToWords(apiRequest).subscribe({
      next: (response) => {
        this.result = response.words;
      },
      error: (error) => {

        this.result = '';
        this.errorMessage = error.error?.error || 'Something went wrong. Please try again.';

      }
    })

  }
}
