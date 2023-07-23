import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToolbarComponent } from "./modules/core/ui/toolbar/toolbar.component";
import { ConfigurationService } from './modules/core/services/configuration.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    declarations: [
        AppComponent
    ],
    providers: [
      {
        provide: APP_INITIALIZER,
        deps: [ConfigurationService],
        multi: true,
        useFactory: (configurationService: ConfigurationService) => () => configurationService.loadConfiguration()
      }
    ],
    bootstrap: [AppComponent],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        BrowserAnimationsModule,
        ToolbarComponent,
    ]
})
export class AppModule { }
