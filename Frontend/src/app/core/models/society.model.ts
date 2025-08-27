
export interface Society {
  id: number;
  name: string;
  address: string;
  city: string;
  phone: string;
  fax: string;
  email: string;
  website: string;
  registrationNo: string;
  
  // Interest rates
  dividendRate: number;
  odRate: number;
  cdRate: number;
  loanRate: number;
  emergencyLoanRate: number;
  lasRate: number;
  
  // Limits
  shareLimit: number;
  loanLimit: number;
  emergencyLoanLimit: number;
  
  // Bounce charge
  bounceChargeAmount: number;
  bounceChargeType: string;
  
  isPendingApproval: boolean;
  createdAt: Date;
  updatedAt: Date;
}

export interface CreateSociety {
  name: string;
  address: string;
  city: string;
  phone: string;
  fax: string;
  email: string;
  website: string;
  registrationNo: string;
  
  dividendRate: number;
  odRate: number;
  cdRate: number;
  loanRate: number;
  emergencyLoanRate: number;
  lasRate: number;
  
  shareLimit: number;
  loanLimit: number;
  emergencyLoanLimit: number;
  
  bounceChargeAmount: number;
  bounceChargeType: string;
}
