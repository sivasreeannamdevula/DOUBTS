import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AbsoluteComponent } from './absolute.component';

describe('AbsoluteComponent', () => {
  let component: AbsoluteComponent;
  let fixture: ComponentFixture<AbsoluteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AbsoluteComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AbsoluteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
