import { KeycloakService } from 'keycloak-angular';
import { environment } from 'src/environments/environment';
 
export function initializer(keycloak: KeycloakService): () => Promise<any> {
  return (): Promise<any> => keycloak.init({
    config: environment.keycloakConfig,
    initOptions: {
      onLoad: 'login-required',
      checkLoginIframe: true
    },
    bearerExcludedUrls: [
      '\/mtc',
      '/wordpress',
      '/events',
      '/assets',
      '/releasenotes',
      '/clients/public',
      '/twitter/public-timeline',
      '/pages/forms/datepicker'
    ],
    enableBearerInterceptor: true,
    loadUserProfileAtStartUp: false
  });
}