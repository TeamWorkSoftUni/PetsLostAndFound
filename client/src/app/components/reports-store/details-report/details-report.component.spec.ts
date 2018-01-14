import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DetailsReportComponent } from './details-report.component';

describe('DetailsReportComponent', () => {
  let component: DetailsReportComponent;
  let fixture: ComponentFixture<DetailsReportComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DetailsReportComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DetailsReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
