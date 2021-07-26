export class Vault {
  constructor(data) {
    this.id = data.id
    this.creatorId = data.creatorId
    this.description = data.description
    this.name = data.name
    this.isPrivate = data.isPrivate
  }
}
