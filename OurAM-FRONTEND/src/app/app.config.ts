import {ApplicationConfig, importProvidersFrom, provideZoneChangeDetection} from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import {provideHttpClient} from "@angular/common/http";
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { SocialAuthServiceConfig, SocialLoginModule, GoogleLoginProvider } from '@abacritt/angularx-social-login';
import {provideNativeDateAdapter} from "@angular/material/core";
import {IMAGE_CONFIG} from "@angular/common";

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient(),
    provideAnimationsAsync(),
    provideNativeDateAdapter(),
    {
      provide: 'SocialAuthServiceConfig',
      useValue: {
        autoLogin: false,
        providers: [
          {
            id: GoogleLoginProvider.PROVIDER_ID,
            provider: new GoogleLoginProvider(
              '427562018701-lpe4868gn7l6m6umosqkv62v70gste30.apps.googleusercontent.com'
            )
          }
        ],
        onError: (error) => {
          console.error(error);
        }
      } as SocialAuthServiceConfig,
    },
    {
      provide: IMAGE_CONFIG,
      useValue: {
        placeholderResolution: 40,
        resolution: 1,
      }
    }
  ]
};
