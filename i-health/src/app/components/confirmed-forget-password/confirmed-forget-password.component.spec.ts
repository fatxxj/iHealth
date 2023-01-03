import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfirmedForgetPasswordComponent } from './confirmed-forget-password.component';

describe('ConfirmedForgetPasswordComponent', () => {
  let component: ConfirmedForgetPasswordComponent;
  let fixture: ComponentFixture<ConfirmedForgetPasswordComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConfirmedForgetPasswordComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConfirmedForgetPasswordComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
