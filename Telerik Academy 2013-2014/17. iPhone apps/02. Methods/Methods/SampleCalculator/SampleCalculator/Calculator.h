#import <Foundation/Foundation.h>

@interface Calculator : NSObject

@property (nonatomic, strong) NSNumber *currentResult;

+(Calculator *) calculatorWithCurrentValue: (NSNumber *) currentValue;

-(NSNumber *) saveResult: (NSNumber *) value;

-(NSNumber *) addValue: (NSNumber *) value;

-(NSNumber *) divideByValue: (NSNumber *) value;

-(NSNumber *) subtractValue: (NSNumber *) value;

-(NSNumber *) multiplyByValue: (NSNumber *) value;

@end