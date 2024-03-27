import { Component, OnInit } from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-roles-modal',
  templateUrl: './roles-modal.component.html',
  styleUrls: ['./roles-modal.component.css']
})
export class RolesModalComponent implements OnInit {
  
  username = '';
  availableRoles: any[] = [];
  selectedRoles: any[] = [];
  


  constructor(public bsModalRef: BsModalRef){}
  
  
  ngOnInit(): void {
   
  }


  updateChecked(checkedValue: string) {
    const index = this.selectedRoles.indexOf(checkedValue);

    index == -1 ? this.selectedRoles.push(checkedValue) : this.selectedRoles.splice(index, 1); // if index is  -1 this means the checked value is not(or was not found) in list and it must be added , otherwise it must be deleted.

    
  }

}
