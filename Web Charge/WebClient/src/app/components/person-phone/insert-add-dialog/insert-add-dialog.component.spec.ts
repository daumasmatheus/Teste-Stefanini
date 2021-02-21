import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertAddDialogComponent } from './insert-add-dialog.component';

describe('InsertAddDialogComponent', () => {
  let component: InsertAddDialogComponent;
  let fixture: ComponentFixture<InsertAddDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InsertAddDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InsertAddDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
