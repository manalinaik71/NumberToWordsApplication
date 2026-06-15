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
    amount:''
  }
  result = '';
  errorMessage = '';

  constructor(private numberConversionService : NumberToWordConversionService){

  }


  onSubmit():void{
    this.result = '';
    this.errorMessage = '';

    const amountValue = this.request.amount.trim();
    const amountParts = amountValue.split(',');
    const number = Number(amountParts[0]);
   
    const cents = amountParts.length > 1 ? 
                  (amountParts[1].length == 1 ? Number(amountParts[1] + '0') : Number(amountParts[1])) : 0;
   
    
    if(cents < 0 || cents > 99){
      this.errorMessage = "Please enter a valid cents value between 0 and 99.";
       this.result = '';
      return;

    }

    if(number < 0 || number > 999999999){
      this.errorMessage = 'Please enter a number between 0 and 999,999,999.';
      this.result = '';

      return;
    }
    
    const apiRequest = {
      language : this.request.language,
      number : number,
      cents : cents
    };

    this.numberConversionService.ConvertNumberToWords(apiRequest).subscribe({
      next:(response) =>{
        this.result = response.words;
      },
      error:(error)=>{
        this.errorMessage = error;
        this.result = '';
      }
    })
  
  }
}
