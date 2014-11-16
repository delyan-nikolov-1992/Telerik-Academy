#import "Calculator.h"

@implementation Calculator

+(Calculator *) calculatorWithCurrentValue: (NSNumber *) currentValue {
    Calculator *calculator = [[Calculator alloc] init];
    
    calculator.currentResult = [[NSNumber alloc] initWithFloat: [currentValue floatValue]];
    
    return calculator;
}

-(NSNumber *) saveResult: (NSNumber *) value {
    self.currentResult = value;
    
    return self.currentResult;
}

-(NSNumber *) addValue: (NSNumber *) value {
    NSNumber *sum = [NSNumber numberWithFloat:([self.currentResult floatValue] + [value floatValue])];
    
    return [self saveResult: sum];
}

-(NSNumber *) divideByValue: (NSNumber *) value {
    NSNumber *division = [NSNumber numberWithFloat:([self.currentResult floatValue] / [value floatValue])];
    
    return [self saveResult: division];
}

-(NSNumber *) subtractValue: (NSNumber *) value {
    NSNumber *subtraction = [NSNumber numberWithFloat:([self.currentResult floatValue] - [value floatValue])];
    
    return [self saveResult: subtraction];
}

-(NSNumber *) multiplyByValue: (NSNumber *) value {
    NSNumber *multiplication = [NSNumber numberWithFloat:([self.currentResult floatValue] * [value floatValue])];
    
    return [self saveResult: multiplication];
}

@end