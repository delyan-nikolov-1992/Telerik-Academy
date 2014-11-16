#import <Foundation/Foundation.h>

@protocol Fightable <NSObject>

-(void) punch: (id) other;

-(void) kick: (id) other;

-(void) useSkillAt: (int) position
           against: (id) other;

@end