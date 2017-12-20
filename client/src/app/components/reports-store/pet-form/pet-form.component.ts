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
  public hasPetType: boolean = false
  public hasPetDescription: boolean = false

  constructor() {
    this.model = {
      petType: '',
      petName: '',
      age: '',
      description: ''
    }
    console.log('tuks')
   }

  ngOnInit() {
    
  }

  isPetTypeValid(e){
    console.log(e)
    if(e.target.value.length > 2){
      this.hasPetType = true
    }
  }

  isDescriptionValid(e){
    if(e.target.value.length > 3){
      this.hasPetDescription = true
    }
  }

  petFillData(event){
    this.newPet.emit(this.model)
  }
}
