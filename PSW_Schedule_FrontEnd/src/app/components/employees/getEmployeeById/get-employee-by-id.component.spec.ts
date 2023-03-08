import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GetEmployeeByIdComponent } from './get-employee-by-id.component';

describe('GetEmployeeByIdComponent', () => {
  let component: GetEmployeeByIdComponent;
  let fixture: ComponentFixture<GetEmployeeByIdComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GetEmployeeByIdComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GetEmployeeByIdComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
