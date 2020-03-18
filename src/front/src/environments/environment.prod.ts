import { KeycloakConfig } from 'keycloak-angular';

let keycloakConfig: KeycloakConfig = {
  url: 'http://id.poc.com.br/auth',
  realm: 'poc',
  clientId: 'account',
  "credentials": {
    "secret": "your-client-secret"
  }
};

export const environment = {
  production: true,
  apiURL: 'http://api.poc.com.br/api',
  keycloakConfig: keycloakConfig
};
