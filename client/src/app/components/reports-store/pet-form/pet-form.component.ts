import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';


@Component({
  selector: 'app-pet-form',
  templateUrl: './pet-form.component.html',
  styleUrls: ['./pet-form.component.css']
})
export class PetFormComponent implements OnInit {
  @Input() statusType: string
  @Input() isLost: boolean
  model: {}
  public petToRegister: FormGroup;
  @Output() newPet = new EventEmitter<Object>()

  constructor() {
    this.model = {
      petType: '',
      petName: '',
      age: '',
      description: ''
    }
   }

  ngOnInit() {
    
  }

 

  petFillData(event){
    this.newPet.emit(this.model)
  }
}
