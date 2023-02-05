import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-button',
  templateUrl: './button.component.html',
  styleUrls: ['./button.component.scss']
})
export class ButtonComponent implements OnInit {
  @Input()
  isLoading: boolean = false;

  @Input()
  disabled: boolean = false;

  @Output()
  click = new EventEmitter<void>();

  constructor() { }

  ngOnInit(): void { }
}
