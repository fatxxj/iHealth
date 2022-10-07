import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PlaningPrincingComponent } from './planing-princing.component';

describe('PlaningPrincingComponent', () => {
  let component: PlaningPrincingComponent;
  let fixture: ComponentFixture<PlaningPrincingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PlaningPrincingComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PlaningPrincingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
