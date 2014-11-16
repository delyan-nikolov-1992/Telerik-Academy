#import <Foundation/Foundation.h>

void printMatrix(NSArray *matrix) {
    NSMutableString *buffer = [[NSMutableString alloc] init];
    
    for (NSArray *row in matrix) {
        for (NSNumber *cell in row) {
            [buffer appendFormat:@"%3d", [cell intValue]];
        }
        
        [buffer appendString:@"\n"];
    }
    
    NSLog(@"\n%@", buffer);
}

NSArray* createSpiralMatrix(int size) {
    NSMutableArray *matrix = [[NSMutableArray alloc] initWithCapacity:size];
    
    for (int i = 0; i < size; i++) {
        matrix[i] = [[NSMutableArray alloc] initWithCapacity:size];
        
        for (int j = 0; j < size; j++) {
            matrix[i][j] = [NSNull null];
        }
    }
    
    int pos = 1;
    int count = size;
    int value = -size;
    int sum = -1;
    
    do {
        value = -1 * value / size;
        
        for (int i = 0; i < count; i++) {
            sum += value;
            matrix[sum / size][sum % size] = [NSNumber numberWithInt:pos++];
        }
        
        value *= size;
        count--;
        
        for (int i = 0; i < count; i++) {
            sum += value;
            matrix[sum / size][sum % size] = [NSNumber numberWithInt:pos++];
        }
    } while (count > 0);
    
    return matrix;
}

int main(int argc, const char * argv[]) {
    @autoreleasepool {
        NSArray *matrix = createSpiralMatrix(5);
        printMatrix(matrix);
    }
    
    return 0;
}