import { OfficeService } from './../office/office.service';
import { OfficeModalComponent } from './../office/office-modal/office-modal.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { PoCheckboxGroupOption, PoModalAction, PoModalComponent, PoRadioGroupOption } from '@po-ui/ng-components';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  @ViewChild(OfficeModalComponent, { static: true }) officeModalComponent: OfficeModalComponent;

  
  content;
  size;
  title;

  primaryActionLabel: string;
  primaryActionProperties: Array<string>;
  primaryActionOptions: Array<PoCheckboxGroupOption> = [
    { value: 'danger', label: 'Danger' },
    { value: 'disabled', label: 'Disabled' },
    { value: 'loading', label: 'Loading' }
  ];


  secondaryActionLabel: string;
  secondaryActionProperties: Array<string>;
  secondaryActionOptions: Array<PoCheckboxGroupOption> = [
    { value: 'disabled', label: 'Disabled' },
    { value: 'loading', label: 'Loading' },
    { value: 'danger', label: 'Danger' }
  ];

  propertiesOptions: Array<PoCheckboxGroupOption> = [
    { value: 'click-out', label: 'Click Out' },
    { value: 'hide-close', label: 'Hide Close' }
  ];


  properties: Array<string>;

  sizeOptions: Array<PoRadioGroupOption> = [
    { label: 'Small', value: 'sm' },
    { label: 'Medium', value: 'md' },
    { label: 'Large', value: 'lg' },
    { label: 'Extra large', value: 'xl' },
    { label: 'Automatic', value: 'auto' }
  ];

  openModal(id:Number) {

    this.officeModalComponent.openModal(id);
  }

  public trilha :any[];

  constructor(private officeService:OfficeService) { }

  ngOnInit() {
    this.restore();

      this.officeService
      .getAll()
      .subscribe((trilha: Array<any>) => {
        this.trilha = trilha;

        console.log(this.trilha)
    });
  }

  restore() {
    this.size = undefined;
    this.content = undefined;
    this.title = 'PO Modal';
    this.properties = [];
    this.primaryActionLabel = undefined;
    this.primaryActionProperties = [];
    this.secondaryActionLabel = undefined;
    this.secondaryActionProperties = [];
  }

}
