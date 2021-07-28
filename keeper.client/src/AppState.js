import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  account: {},
  keeps: [],
  userVaults: [],
  activeProfile: {},
  activeKeep: {},
  activeProfileKeeps: [],
  activeProfileVaults: [],
  activeVault: {},
  activeVaultKeeps: [],
  newVault: {},
  newKeep: {},
  newVaultKeep: {}
})
