import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './Navbar.component';

@NgModule({
  imports: [CommonModule],
  declarations: [NavbarComponent],
  exports: [NavbarComponent]
})
export class NavbarModule {}
