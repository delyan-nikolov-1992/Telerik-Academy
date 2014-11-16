#import <Foundation/Foundation.h>

#import "Calculator.h"

int main(int argc, const char * argv[]) {
    @autoreleasepool {
        NSNumber *startValue = [NSNumber numberWithFloat: 15.5];
        Calculator *calculator = [Calculator calculatorWithCurrentValue: startValue];
        NSLog(@"Initial: %f\n", [[calculator currentResult] floatValue]);
        
        [calculator addValue: startValue];
        NSLog(@"After addition: %f\n", [[calculator currentResult] floatValue]);
        
        [calculator divideByValue: startValue];
        NSLog(@"After division: %f\n", [[calculator currentResult] floatValue]);
        
        [calculator subtractValue: startValue];
        NSLog(@"After subtraction: %f\n", [[calculator currentResult] floatValue]);
        
        [calculator multiplyByValue: startValue];
        NSLog(@"After multiplication: %f\n", [[calculator currentResult] floatValue]);
    }
    
    return 0;
}